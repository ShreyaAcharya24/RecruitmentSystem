using OfficeOpenXml;
using RecruitmentSystem.Models;
using RecruitmentSystem.Service.Impl;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentSystem.Service
{
    public class CandidateExcelService
    {
        private readonly CandidateService _candidateService;

        public CandidateExcelService(CandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        public async Task<string> BulkInsertCandidatesFromExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "File not found.";

            var candidates = new List<Candidate>();

            // Read the Excel file
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Read the first worksheet
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Skip header row
                    {
                        var candidate = new Candidate
                        {
                            FirstName = worksheet.Cells[row, 1].Text,
                            LastName = worksheet.Cells[row, 2].Text,
                            Age = int.TryParse(worksheet.Cells[row, 3].Text, out int age) ? age : 0,
                            Gender = worksheet.Cells[row, 4].Text,
                            Contact = worksheet.Cells[row, 5].Text,
                            AddressLine1 = worksheet.Cells[row, 6].Text,
                            AddressLine2 = worksheet.Cells[row, 7].Text,
                            HighestQualification = worksheet.Cells[row, 8].Text,
                            SchoolOrUniversity = worksheet.Cells[row, 9].Text,
                            ScoreGPA = double.TryParse(worksheet.Cells[row, 10].Text, out double score) ? score : 0,
                            TotalExperience = int.TryParse(worksheet.Cells[row, 11].Text, out int experience) ? experience : 0,
                            RUser = new RUser
                            {
                                Email = worksheet.Cells[row, 12].Text,
                                Password = worksheet.Cells[row, 13].Text
                            }
                        };

                        candidates.Add(candidate);
                    }
                }
            }

            // Save candidates to the database
            foreach (var candidate in candidates)
            {
                var result = await _candidateService.AddCandidate(candidate, null); // Null for now for resume upload, handle as needed
            }

            return "Candidates imported successfully.";
        }
    }
}

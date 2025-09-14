using ClosedXML.Excel;
namespace TestProject2
{
    public static class ExcelUtils
    {
        public static string ReadCell(string filePath, string sheetName, int row, int col)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Excel file not found: {filePath}");
            using var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet(sheetName);
            var cellValue = worksheet.Cell(row + 1, col + 1).GetValue<string>();
            return cellValue;
        }
    }
}

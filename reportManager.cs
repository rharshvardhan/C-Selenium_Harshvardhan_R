using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

public static class ReportManager
{
    private static ExtentReports extent;

    public static ExtentReports GetInstance()
    {
        if (extent == null)
        {
            var htmlReporter = new ExtentSparkReporter("TestReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        return extent;
    }
}

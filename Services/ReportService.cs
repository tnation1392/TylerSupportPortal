using System;
using System.Collections.Generic;
using System.Text;

using TylerSupportPortal.Tests.Models;

namespace TylerSupportPortal.Tests.Services;

public class ReportService
{
    public Report GenerateReport(string name)
    {
        return new Report
        {
            Name = name,
            GeneratedDate = DateTime.Today
        };
    }
}

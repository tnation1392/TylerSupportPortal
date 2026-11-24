using System;
using System.Collections.Generic;
using System.Text;

using TylerSupportPortal.Tests.Models;

namespace TylerSupportPortal.Tests.Services;

//A class used for report testing

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

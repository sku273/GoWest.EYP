using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EYPDataService.Entities
{
    public enum Status
    {
        Open,
        InProgress,
        Closed
    }

    public enum QuestionType
    {
        PerformanceFeedback,
        GrowthPlan,
        StabilityAnalysis
    }
}
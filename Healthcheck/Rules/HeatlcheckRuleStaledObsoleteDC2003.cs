﻿//
// Copyright (c) Ping Castle. All rights reserved.
// https://www.pingcastle.com
//
// Licensed under the Non-Profit OSL. See LICENSE file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Text;
using PingCastle.Rules;

namespace PingCastle.Healthcheck.Rules
{
	[RuleModel("S-DC-2003", RiskRuleCategory.StaleObjects, RiskModelCategory.ObsoleteOS)]
	[RuleComputation(RuleComputationType.TriggerOnPresence, 20)]
    [RuleSTIG("V-8551", "The domain functional level must be at a Windows Server version still supported by Microsoft.")]
	[RuleANSSI("R12", "subsection.3.1")]
    public class HeatlcheckRuleStaledObsoleteDC2003 : RuleBase<HealthcheckData>
    {
		protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
        {
			int w2003 = 0;
            foreach (var dc in healthcheckData.DomainControllers)
            {
                if (dc.OperatingSystem == "Windows 2003")
                {
                    w2003++;
                }
            }
			return w2003;
        }
    }
}

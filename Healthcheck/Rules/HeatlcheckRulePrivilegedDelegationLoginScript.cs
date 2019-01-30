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
	[RuleModel("P-DelegationLoginScript", RiskRuleCategory.PrivilegedAccounts, RiskModelCategory.ACLCheck)]
	[RuleComputation(RuleComputationType.PerDiscover, 15)]
	[RuleANSSI("R18", "subsubsection.3.3.2")]
	public class HeatlcheckRulePrivilegedDelegationLoginScript : RuleBase<HealthcheckData>
    {
		protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
        {
			foreach (var script in healthcheckData.LoginScript)
			{
				if (script.Delegation != null)
				{
					foreach (var delegation in script.Delegation)
					{
						AddRawDetail(script.LoginScript, delegation.Account, delegation.Right);
					}
				}
			}
			foreach (var script in healthcheckData.GPOLoginScript)
			{
				if (script.Delegation != null)
				{
					foreach (var delegation in script.Delegation)
					{
						AddRawDetail(script.CommandLine, delegation.Account, delegation.Right);
					}
				}
			}
			return null;
        }
    }
}

﻿using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace LINGYUN.Abp.Auditing.Features
{
    public class AuditingFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var auditingGroup = context.AddGroup(
                name: AuditingFeatureNames.GroupName,
                displayName: L("Features:Auditing"));

            auditingGroup.AddFeature(
                name: AuditingFeatureNames.AuditLog.Default,
                defaultValue: true.ToString(),
                displayName: L("Features:DisplayName:AuditLog"),
                description: L("Features:Description:AuditLog"),
                valueType: new ToggleStringValueType(new BooleanValueValidator())
                );
            auditingGroup.AddFeature(
                name: AuditingFeatureNames.SecurityLog.Default,
                defaultValue: true.ToString(),
                displayName: L("Features:DisplayName:SecurityLog"),
                description: L("Features:Description:SecurityLog"),
                valueType: new ToggleStringValueType(new BooleanValueValidator())
                );
        }

        protected LocalizableString L(string name)
        {
            return LocalizableString.Create<AuditLoggingResource>(name);
        }
    }
}

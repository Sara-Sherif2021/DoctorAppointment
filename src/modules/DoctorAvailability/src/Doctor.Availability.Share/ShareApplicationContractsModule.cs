using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Doctor.Availability.Share;

[DependsOn(
    typeof(AbpDddApplicationContractsModule)
)]
public class ShareApplicationContractsModule : AbpModule
{

}

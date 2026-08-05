using System;
using HCloudAPI.Api;
using HCloudAPI.Clients;
using HCloudAPI.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HCloudAPI
{
    /// <summary>
    /// Client for API interactions.
    /// </summary>
    /// <param name="bearerToken">Your Hetzner Cloud API token, created in your cloud panel. ( https://console.hetzner.com )</param>
    public class Client(string bearerToken)
    {
        private IHost HostBuild =>
            Host.CreateDefaultBuilder().ConfigureApi((_, options) =>
            {
                BearerToken token = new(bearerToken);
                options.AddTokens(token);

                options.UseProvider<RateLimitProvider<BearerToken>, BearerToken>();

                options.AddApiHttpClients(
                    client => { client.BaseAddress = new Uri("https://api.hetzner.cloud/v1/"); },
                    builder =>
                    {
                        builder
                            .AddRetryPolicy(2)
                            .AddTimeoutPolicy(TimeSpan.FromSeconds(5))
                            .AddCircuitBreakerPolicy(10, TimeSpan.FromSeconds(30));
                    }
                );
            }).ConfigureLogging(logging =>
            {
                logging.AddFilter("System.Net.Http.HttpClient", LogLevel.Warning);
                logging.AddFilter("HCloudAPI.Api", LogLevel.Warning);
            }).Build();

        /// <summary>
        /// <see cref="IActionsApi"/>>
        /// </summary>
        public IActionsApi ActionsApi {
            get => HostBuild.Services.GetRequiredService<IActionsApi>();
            private set;
        }
        
        /// <summary>
        /// <see cref="ICertificateActionsApi"/>
        /// </summary>
        public ICertificateActionsApi CertificateActionsApi { 
            get => HostBuild.Services.GetRequiredService<ICertificateActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="ICertificatesApi"/>>
        /// </summary>
        public ICertificatesApi CertificatesApi { 
            get => HostBuild.Services.GetRequiredService<ICertificatesApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IDataCentersApi"/>
        /// </summary>
        public IDataCentersApi DataCentersApi { 
            get => HostBuild.Services.GetRequiredService<IDataCentersApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IFirewallActionsApi"/>
        /// </summary>
        public IFirewallActionsApi FirewallActionsApi { 
            get => HostBuild.Services.GetRequiredService<IFirewallActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IFirewallsApi"/>
        /// </summary>
        public IFirewallsApi FirewallsApi { 
            get => HostBuild.Services.GetRequiredService<IFirewallsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IFloatingIPActionsApi"/>
        /// </summary>
        public IFloatingIPActionsApi FloatingIpActionsApi { 
            get => HostBuild.Services.GetRequiredService<IFloatingIPActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IFloatingIPsApi"/>
        /// </summary>
        public IFloatingIPsApi FloatingIPsApi { 
            get => HostBuild.Services.GetRequiredService<IFloatingIPsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IImageActionsApi"/>
        /// </summary>
        public IImageActionsApi ImageActionsApi { 
            get => HostBuild.Services.GetRequiredService<IImageActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IImagesApi"/>
        /// </summary>
        public IImagesApi ImagesApi { 
            get => HostBuild.Services.GetRequiredService<IImagesApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IISOsApi"/>
        /// </summary>
        public IISOsApi ISOsApi { 
            get => HostBuild.Services.GetRequiredService<IISOsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="ILoadBalancerActionsApi"/>
        /// </summary>
        public ILoadBalancerActionsApi LoadBalancerActionsApi {  
            get => HostBuild.Services.GetRequiredService<ILoadBalancerActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="ILoadBalancersApi"/>
        /// </summary>
        public ILoadBalancersApi LoadBalancersApi { 
            get => HostBuild.Services.GetRequiredService<ILoadBalancersApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="ILoadBalancerTypesApi"/>
        /// </summary>
        public ILoadBalancerTypesApi LoadBalancerTypesApi { 
            get => HostBuild.Services.GetRequiredService<ILoadBalancerTypesApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="ILocationsApi"/>
        /// </summary>
        public ILocationsApi LocationsApi { 
            get => HostBuild.Services.GetRequiredService<ILocationsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="INetworkActionsApi"/>
        /// </summary>
        public INetworkActionsApi NetworkActionsApi { 
            get => HostBuild.Services.GetRequiredService<INetworkActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="INetworksApi"/>
        /// </summary>
        public INetworksApi NetworksApi { 
            get => HostBuild.Services.GetRequiredService<INetworksApi>();
            private set;
        }
        
        /// <summary>
        /// <see cref="IPlacementGroupsApi"/>
        /// </summary>
        public IPlacementGroupsApi PlacementGroupsApi { 
            get => HostBuild.Services.GetRequiredService<IPlacementGroupsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IPricingApi"/>
        /// </summary>
        public IPricingApi PricingApi { 
            get => HostBuild.Services.GetRequiredService<IPricingApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IPrimaryIPActionsApi"/>
        /// </summary>
        public IPrimaryIPActionsApi PrimaryIpActionsApi { 
            get => HostBuild.Services.GetRequiredService<IPrimaryIPActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IPrimaryIPsApi"/>
        /// </summary>
        public IPrimaryIPsApi PrimaryIPsApi { 
            get => HostBuild.Services.GetRequiredService<IPrimaryIPsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IServerActionsApi"/>
        /// </summary>
        public IServerActionsApi ServerActionsApi { 
            get => HostBuild.Services.GetRequiredService<IServerActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IServersApi"/>
        /// </summary>
        public IServersApi ServersApi { 
            get => HostBuild.Services.GetRequiredService<IServersApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IServerTypesApi"/>
        /// </summary>
        public IServerTypesApi ServerTypesApi { 
            get => HostBuild.Services.GetRequiredService<IServerTypesApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="ISSHKeysApi"/>
        /// </summary>
        public ISSHKeysApi SShKeysApi { 
            get => HostBuild.Services.GetRequiredService<ISSHKeysApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IVolumeActionsApi"/>
        /// </summary>
        public IVolumeActionsApi VolumeActionsApi { 
            get => HostBuild.Services.GetRequiredService<IVolumeActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IVolumesApi"/>
        /// </summary>
        public IVolumesApi VolumesApi { 
            get => HostBuild.Services.GetRequiredService<IVolumesApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IZoneActionsApi"/>
        /// </summary>
        public IZoneActionsApi ZoneActionsApi { 
            get => HostBuild.Services.GetRequiredService<IZoneActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IZoneRRSetActionsApi"/>
        /// </summary>
        public IZoneRRSetActionsApi ZoneRrSetActionsApi { 
            get => HostBuild.Services.GetRequiredService<IZoneRRSetActionsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IZoneRRSetsApi"/>
        /// </summary>
        public IZoneRRSetsApi ZoneRrSetsApi { 
            get => HostBuild.Services.GetRequiredService<IZoneRRSetsApi>();
            private set; 
        }
        
        /// <summary>
        /// <see cref="IZonesApi"/>
        /// </summary>
        public IZonesApi ZonesApi { 
            get => HostBuild.Services.GetRequiredService<IZonesApi>();
            private set; 
        }
    }
}
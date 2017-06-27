using AlienDetector.DataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienDetector
{
    class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<AlienModel> AlienModelTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://aliendetector.azurewebsites.net");
            this.AlienModelTable = this.client.GetTable<AlienModel>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }
        public async Task<List<AlienModel>> GetAlienInformation()
        {
            return await this.AlienModelTable.ToListAsync();
        }

        public async Task PostAlienInformation(AlienModel AlienDetectorModel)
        {
            await this.AlienModelTable.InsertAsync(AlienDetectorModel);
        }
    }
}

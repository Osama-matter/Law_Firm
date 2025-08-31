using Law_Firm.Models.ClsDatabase;
using Law_Firm.Models.dbContext;
using Law_Firm.Reosertiry.Interface;
using Microsoft.EntityFrameworkCore;

namespace Law_Firm.Reosertiry
{
    public class ServicesRepositiry : Iservicees
    {
        LawFirmdbContext dbcontext; 
        public  ServicesRepositiry(LawFirmdbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public void Add(ServiceModel serviceModel)
        {
            dbcontext.Add(serviceModel);
        }

        public bool Delete(int ID)
        {
            ServiceModel serviceModel = Find_Using_ID(ID);  

            if (serviceModel != null)
            {
                dbcontext.Services.Remove(serviceModel);    

                return true;
            }
            return false;
        }

        public void Edit(ServiceModel serviceModel)
        {
            dbcontext.Update(serviceModel); 
        }

        public ServiceModel Find_Using_ID(int ID)
        {
            return dbcontext.Services.FirstOrDefault(e => e.Id == ID);   
        }

        public List<ServiceModel> Get_All()
        {
            return  dbcontext.Services.ToList();     

        }

        public void Save()
        {
            dbcontext.SaveChanges();
        }
    }
}

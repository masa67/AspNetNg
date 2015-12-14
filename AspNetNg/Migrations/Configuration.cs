namespace AspNetNg.Migrations
{
    using Models;
    using DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetNg.DAL.GrievanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspNetNg.DAL.GrievanceContext context)
        {
            DAL.GrievanceRepository repo = new GrievanceRepository();

            repo.DeleteAll<ActionDirectory>(ad => ad.ActionID == ad.ActionID);
            repo.DeleteAll<Models.Action>(a => a.ActionId == a.ActionId);
            repo.DeleteAll<Filesystem>(fs => fs.DirectoryID == fs.DirectoryID);
            repo.DeleteAll<GrievanceStep>(g => g.GrievanceStepID == g.GrievanceStepID);
            repo.DeleteAll<Grievance>(g => g.GrievanceId == g.GrievanceId);

            Grievance grievance1 = new Grievance { GrievanceId = Guid.NewGuid() };
            repo.Save<Grievance>(grievance1);

            GrievanceStep grievanceStep1 = new GrievanceStep { GrievanceStepID = Guid.NewGuid(), GrievanceID = grievance1.GrievanceId };
            repo.Save<GrievanceStep>(grievanceStep1);

            Filesystem filesystem1 = new Filesystem { DirectoryID = Guid.NewGuid() };
            repo.Save<Filesystem>(filesystem1);

            Models.Action action1 = new Models.Action { ActionId = Guid.NewGuid() };
            Models.Action action2 = new Models.Action { ActionId = Guid.NewGuid() };
            repo.Save<Models.Action>(action1);
            repo.Save<Models.Action>(action2);

            ActionDirectory actionDirectory1 = new ActionDirectory { ActionID = action1.ActionId, DirectoryID = filesystem1.DirectoryID, GrievanceStepID = grievanceStep1.GrievanceStepID };
            ActionDirectory actionDirectory2 = new ActionDirectory { ActionID = action2.ActionId, DirectoryID = filesystem1.DirectoryID, GrievanceStepID = grievanceStep1.GrievanceStepID };
            repo.Save<ActionDirectory>(actionDirectory1);
            repo.Save<ActionDirectory>(actionDirectory2);

            /*
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();
            */

            Guid id = grievanceStep1.GrievanceStepID;
            GrievanceStep step = context.GrievanceStep.SingleOrDefault(gs => gs.GrievanceStepID == id);
            foreach (ActionDirectory ad in step.ActionDirectories)
            {
                Filesystem fs = ad.Directory;
                fs.DirectoryID = fs.DirectoryID;
            }

            try
            {
                context.MyOrderModel.AddOrUpdate(
                    p => p.Id,
                    new PostPayQRCodeFuelOrderModel
                    {
                        Id = 1,
                        OrderNumber = "00001",
                        Details = new List<MyOrderDetailModel>()
                        {
                            new MyOrderDetailModel()
                            {
                                Amount = 5.67M
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}

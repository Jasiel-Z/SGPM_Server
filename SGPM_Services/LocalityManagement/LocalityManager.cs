﻿using SGPM_Contracts.ILocalityManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : ILocalityManagement
    {
        public int SaveLocality(Locality locality)
        {
            int result = 0;
            try
            {
                using (var context = new SGPMEntities())
                {
                    Localidades localityToBeSaved = new Localidades();
                    localityToBeSaved.nombre = locality.Name;
                    localityToBeSaved.municipio = locality.Township;

                    context.Localidades.Add(localityToBeSaved);
                    result = context.SaveChanges();
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }
            catch (DbEntityValidationException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }
            catch (EntityException exception)
            {
                Console.WriteLine(exception.Message);
                result = -1;
            }

            return result;
        }

        public bool ValidateLocalityDoesNotExist(string localityName)
        {
            bool isLocalityUnique = false;

            using (var context = new SGPMEntities())
            {
                var locality = context.Localidades.Where(localidad => localidad.nombre == localityName).FirstOrDefault();

                if (locality == null)
                {
                    isLocalityUnique = true;
                }
            }

            return isLocalityUnique;
        }

        public List<Locality> GetLocalities() 
        {         
            List<Locality> localityList = new List<Locality>();

            using (var context = new SGPMEntities())
            {
                var localitiesFromDatabase = context.Localidades.ToList();

                if (localitiesFromDatabase != null)
                {
                    foreach (var locality in localitiesFromDatabase)
                    {
                        localityList.Add(new Locality
                        {
                            LocalityID = locality.IdLocalidad,
                            Name = locality.nombre,
                            Township = locality.municipio
                        });
                    }
                }
                
            }

            return localityList;
        }

        public int UpdateLocality(Locality locality)
        {
            int result = 0;

            try
            {
                using (var context = new SGPMEntities())
                {
                    var localityFromDB = context.Localidades
                                                .Where(localidad => localidad.IdLocalidad == locality.LocalityID)
                                                .SingleOrDefault();

                    if (localityFromDB != null)
                    {
                        localityFromDB.nombre = locality.Name;
                        localityFromDB.municipio = locality.Township;

                        result = context.SaveChanges();
                    }
                }
            } catch (Exception ex) when (ex is DbUpdateException || ex is DbEntityValidationException || ex is InvalidOperationException || ex is SqlException) {
                result = -1;
            }

            return result;
        }
    }
}

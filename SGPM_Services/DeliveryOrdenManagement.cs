using SGPM_Contracts.IDeliveryOrdenManagement;
using SGPM_DataBAse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPM_Services.ProjectsManagement
{
    public partial class SGPMManager : IDeliveryOrdenManagement
    {
        public DeliveryOrden GetDeliveryOrden(int idDeliveryOrden)
        {
            DeliveryOrden deliveryOrden = null;
            using (var context = new SGPMEntities())
            {
                var orden = context.OrdenesEntrega.Where(o => o.IdOrdenEntrega == idDeliveryOrden).FirstOrDefault();
                if (orden != null)
                {
                    deliveryOrden = new DeliveryOrden
                    {
                        Amount = orden.cantidad,
                        DeliveryDate = (DateTime)orden.fechaEntrega,
                        DeliveryPlace = orden.lugarEntrega,
                    };
                    deliveryOrden.Resource = new Resource();
                    deliveryOrden.Resource.IdResource = (int)orden.IdRecurso;
                }
            }
            return deliveryOrden;
        }

        public Collection<Resource> GetResources()
        {
            Collection<Resource> resources = new Collection<Resource>();

            using (var context = new SGPMEntities())
            {
                var resourcesList = context.Recursos.ToList();
                foreach (var resource in resourcesList)
                {
                    Resource resourceItem = new Resource
                    {
                        IdResource = resource.IdRecurso,
                        Name = resource.nombre
                    };
                    resources.Add(resourceItem);
                }
            }
            return resources;
        }

        public int SaveDeliveryOrden(DeliveryOrden deliveryOrden, string folio)
        {
            var result = 1;
            using (var context = new SGPMEntities())
            {
                OrdenesEntrega delivery = new OrdenesEntrega
                {
                    lugarEntrega = deliveryOrden.DeliveryPlace,
                    fechaEntrega = deliveryOrden.DeliveryDate,
                    cantidad = deliveryOrden.Amount,
                    IdRecurso = deliveryOrden.Resource.IdResource
                };
                context.OrdenesEntrega.AddOrUpdate(delivery);
                result -= context.SaveChanges();
                UpdateProjectDeliveryOrden(delivery.IdOrdenEntrega, folio);
            }

            return result;
        }

        private int UpdateProjectDeliveryOrden(int idDeliveryOrden, string idProject)
        {
            var result = 1;
            using (var context = new SGPMEntities())
            {
                var project = context.Proyectos.Where(p => p.Folio == idProject).FirstOrDefault();
                if (project != null)
                {
                    project.IdOrdenEntrega = idDeliveryOrden;
                    result -= context.SaveChanges();
                }
            }

            return result;
        }
    }
}

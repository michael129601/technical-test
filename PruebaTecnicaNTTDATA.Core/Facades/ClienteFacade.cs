using PruebaTecnicaNTTDATA.Core.DTOs;
using PruebaTecnicaNTTDATA.Entity.Connector;
using PruebaTecnicaNTTDATA.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Core.Facades
{
    public class ClienteFacade : FacadeBase
    {
        public ClienteFacade(ApplicationDBContext prmContext) : base(prmContext)
        {

        }

        public async Task<object> Create(ClientesDTO prmCliente )
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {

               return await conector.ClientesRepository().Insert(new Clientes
                {
                    Contrasenia = prmCliente.clave,
                    Estado = prmCliente.estado,
                    Persona = new Persona
                    {
                        Direccion = prmCliente.direccion,
                        Telefono = prmCliente.telefono,
                        Nombre = prmCliente.nombres,
                        Edad = prmCliente.edad,
                        Genero = prmCliente.genero,
                        Identificacion = prmCliente.identificacion
                    } 
                });

            }
        }


        public async Task<object> Update(ClientesUpdateDTO prmCliente,int prmId)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {

                Clientes cliente = await conector.ClientesRepository().GetById(prmId);

                if (cliente == null) return null;
                
                cliente.Contrasenia = String.IsNullOrEmpty(prmCliente.clave) ? cliente.Contrasenia : prmCliente.clave ;
                cliente.Estado =   cliente.Estado;
                cliente.Persona.Direccion = String.IsNullOrEmpty(prmCliente.direccion) ?  cliente.Persona.Direccion : prmCliente.direccion ;
                cliente.Persona.Nombre = String.IsNullOrEmpty(prmCliente.nombres) ? cliente.Persona.Nombre : prmCliente.nombres;
                cliente.Persona.Telefono = String.IsNullOrEmpty(prmCliente.telefono) ? cliente.Persona.Telefono : prmCliente.telefono;

                return await conector.ClientesRepository().Update(cliente);

            }
        }

        public async Task<object> GetAll()
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {

                List<Clientes> lstModels = (List<Clientes>) await conector.ClientesRepository().GetAll();

                List<ClientesResponseDTO> lstDtos = new List<ClientesResponseDTO>();

                foreach (Clientes cliente in lstModels)
                {
                 
                    lstDtos.Add(new ClientesResponseDTO
                    {
                        nombres = cliente.Persona.Nombre,
                        clave = cliente.Contrasenia,
                        direccion = cliente.Persona.Direccion,
                        estado = cliente.Estado,
                        id = cliente.Clienteid,
                        telefono = cliente.Persona.Telefono

                    });
                }
                return lstDtos;

            }
        }

        public async Task<object> GetById(int prmId)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {
                Clientes cliente = (Clientes) await conector.ClientesRepository().GetById(prmId);
                if (cliente == null)
                    return null;

                return new ClientesResponseDTO()
                {
                    nombres = cliente.Persona.Nombre,
                    clave = cliente.Contrasenia,
                    direccion = cliente.Persona.Direccion,
                    estado = cliente.Estado,
                    id = cliente.Clienteid,
                    telefono = cliente.Persona.Telefono

                };

            }
        }

        public async Task<int> Delete(int prmClienteId)
        {
            using (ConnectorRepository conector = new ConnectorRepository(Context))
            {

                return await conector.ClientesRepository().Delete(prmClienteId);

            }
        }


    }

}

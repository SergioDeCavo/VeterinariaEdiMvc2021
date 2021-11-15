using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Cliente;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Localidad;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Mascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Medicamento;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Proveedor;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Raza;
using VeterinariaEdiMvc2021.Entidades.ViewModels.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.ViewModels.Venta;

namespace VeterinariaEdiMvc2021.Mapeador
{
    public class Mapeador
    {
        private static AutoMapper.Mapper _mapper;

        static readonly MapperConfiguration Config = new MapperConfiguration(cfg =>
            cfg.AddProfile<MappingProfile>());

        public static AutoMapper.Mapper CrearMapper()
        {
            _mapper = new AutoMapper.Mapper(Config);
            return _mapper;
        }


        public static List<LocalidadListViewModel> ConstruirListaLocalidadListVm(List<Localidad> listaLocalidades)
        {
            var lista = new List<LocalidadListViewModel>();
            foreach (var localidad in listaLocalidades)
            {
                var localidadVm = ConstruirLocalidadListVm(localidad);
                lista.Add(localidadVm);
            }

            return lista;
        }

        public static LocalidadListViewModel ConstruirLocalidadListVm(Localidad localidad)
        {
            return new LocalidadListViewModel()
            {
                LocalidadId = localidad.LocalidadId,
                NombreLocalidad = localidad.NombreLocalidad,
                Provincia = localidad.Provincia.NombreProvincia
            };
        }

        public static List<RazaListViewModel> ConstruirListaRazaListVm(List<Raza> listaRazas)
        {
            var lista = new List<RazaListViewModel>();
            foreach (var raza in listaRazas)
            {
                var razaVm = ConstruirRazaListVm(raza);
                lista.Add(razaVm);
            }

            return lista;
        }

        private static RazaListViewModel ConstruirRazaListVm(Raza raza)
        {
            return new RazaListViewModel()
            {
                RazaId = raza.RazaId,
                Descripcion = raza.Descripcion,
                TipoDeMascota = raza.TipoDeMascota.Descripcion
            };
        }

        public static List<MascotaListViewModel> ConstruirListaTipoDeMascotaListVm(List<Mascota> listaMascotas)
        {
            var lista = new List<MascotaListViewModel>();
            foreach (var mascota in listaMascotas)
            {
                var mascotaVm = ConstruirMascotaListVm(mascota);
                lista.Add(mascotaVm);
            }

            return lista;
        }

        private static MascotaListViewModel ConstruirMascotaListVm(Mascota mascota)
        {
            return new MascotaListViewModel()
            {
                MascotaId = mascota.MascotaId,
                Nombre = mascota.Nombre,
                TipoDeMascota = mascota.TipoDeMascota.Descripcion,
                Raza = mascota.Raza.Descripcion,
                Cliente = mascota.Cliente.Apellido


            };
        }


        public static List<ClienteListViewModel> ConstruirListaClienteListVm(List<Cliente> listaClientes)
        {
            var lista = new List<ClienteListViewModel>();
            foreach (var cliente in listaClientes)
            {
                var clienteVm = ConstruirClienteListVm(cliente);
                lista.Add(clienteVm);
            }

            return lista;
        }

        public static ClienteListViewModel ConstruirClienteListVm(Cliente cliente)
        {
            return new ClienteListViewModel()
            {
                ClienteId = cliente.ClienteId,
                Apellido = cliente.Apellido,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                Localidad = cliente.Localidad.NombreLocalidad,
                Provincia = cliente.Provincia.NombreProvincia,
                TelefonoFijo = cliente.TelefonoFijo,
                TelefonoMovil = cliente.TelefonoMovil,
                CorreoElectronico = cliente.CorreoElectronico,
            };
        }

        public static List<ProveedorListViewModel> ConstruirListaProveedorListVm(List<Proveedor> listaProveedores)
        {
            var lista = new List<ProveedorListViewModel>();
            foreach (var proveedor in listaProveedores)
            {
                var proveedorVm = ConstruirProveedorListVm(proveedor);
                lista.Add(proveedorVm);
            }

            return lista;
        }

        public static ProveedorListViewModel ConstruirProveedorListVm(Proveedor proveedor)
        {
            return new ProveedorListViewModel()
            {
                ProveedorId = proveedor.ProveedorId,
                CUIT = proveedor.CUIT,
                RazonSocial = proveedor.RazonSocial,
                Direccion = proveedor.Direccion,
                TelefonoMovil = proveedor.TelefonoMovil,
                Localidad = proveedor.Localidad.NombreLocalidad,
            };
        }

        public static List<VentaListViewModel> ConstruirListaVentaListVm(List<Venta> listaVentas)
        {
            var lista = new List<VentaListViewModel>();
            foreach (var venta in listaVentas)
            {
                var ventaVm = ConstruirVentaListVm(venta);
                lista.Add(ventaVm);
            }

            return lista;
        }

        public static VentaListViewModel ConstruirVentaListVm(Venta venta)
        {
            return new VentaListViewModel()
            {
                VentaId = venta.VentaId,
                FechaVenta = venta.FechaVenta,
                Cliente = venta.Cliente.Apellido,
                Anulado= venta.Anulado,
            };
        }

        public static List<MedicamentoListViewModel> ConstruirListaMedicamentoListVm(List<Medicamento> lista)
        {
            var listaVm = new List<MedicamentoListViewModel>();
            foreach (var medicamento in lista)
            {
                var medicamentoVm = Mapeador.ConstruirMedicamentoListVm(medicamento);
                listaVm.Add(medicamentoVm);
            }

            return listaVm;
        }


        public static MedicamentoListViewModel ConstruirMedicamentoListVm(Medicamento medicamento)
        {
            return new MedicamentoListViewModel()
            {
                MedicamentoId = medicamento.MedicamentoId,
                NombreComercial = medicamento.NombreComercial,
                TipoDeMedicamento = medicamento.TipoDeMedicamento.Descripcion,
                FormaFarmaceutica = medicamento.FormaFarmaceutica.Descripcion,
                Laboratorio = medicamento.Laboratorio.Nombre,
                PrecioVenta = medicamento.PrecioVenta,
                Suspendido = medicamento.Suspendido,
            };
        }


    }

}

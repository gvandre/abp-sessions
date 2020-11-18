using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Inteliventas.Erp.Clientes
{
    public class ClienteControl : DomainService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteControl(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> CreateAsync(
            [NotNull] string nombre,
            [CanBeNull] string dni = null,
            [CanBeNull] string ruc = null,
            [CanBeNull] string ce = null)
        {
            Check.NotNullOrWhiteSpace(nombre, nameof(nombre));

            if (string.IsNullOrWhiteSpace(dni) && string.IsNullOrWhiteSpace(ruc) && string.IsNullOrWhiteSpace(ce))
            {
                throw new ExceptionClienteNoData();
            }


            var existeClienteDni = string.IsNullOrWhiteSpace(dni) ? null : await _clienteRepository.FindByDniAsync(dni);

            var existeClienteRuc = string.IsNullOrWhiteSpace(ruc) ? null : await _clienteRepository.FindByRucAsync(ruc);

            var existeClienteCe = string.IsNullOrWhiteSpace(ce) ? null : await _clienteRepository.FindByCeAsync(ce);

            if (existeClienteDni != null)
            {
                throw new ExceptionClienteExiste("dni", dni);
            }

            if (existeClienteRuc != null)
            {
                throw new ExceptionClienteExiste("ruc", ruc);
            }

            if (existeClienteCe != null)
            {
                throw new ExceptionClienteExiste("ce", ce);
            }

            return new Cliente
            {
                Nombre = nombre,
                Dni = dni,
                Ruc = ruc,
                Ce = ce
            };

        }

        public async Task ChangeDniAsync(
            [NotNull] Cliente cliente,
            [CanBeNull] string dni = null)
        {
            Check.NotNull(cliente, nameof(cliente));

            if (!string.IsNullOrWhiteSpace(dni))
            {
                var existeCliente = await _clienteRepository.FindByDniAsync(dni);

                if (existeCliente != null && existeCliente.Id != cliente.Id)
                {
                    throw new ExceptionClienteExiste("dni", dni);
                }
            }

            cliente.Dni = dni;
        }

        public async Task ChangeRucAsync(
            [NotNull] Cliente cliente,
            [CanBeNull] string ruc = null)
        {
            Check.NotNull(cliente, nameof(cliente));

            if (!string.IsNullOrWhiteSpace(ruc))
            {
                var existeCliente = await _clienteRepository.FindByRucAsync(ruc);

                if (existeCliente != null && existeCliente.Id != cliente.Id)
                {
                    throw new ExceptionClienteExiste("ruc", ruc);
                }
            }

            cliente.Ruc = ruc;
        }

        public async Task ChangeCeAsync(
            [NotNull] Cliente cliente,
            [CanBeNull] string ce = null)
        {
            Check.NotNull(cliente, nameof(cliente));

            if (!string.IsNullOrWhiteSpace(ce))
            {
                var existeCliente = await _clienteRepository.FindByCeAsync(ce);

                if (existeCliente != null && existeCliente.Id != cliente.Id)
                {
                    throw new ExceptionClienteExiste("ce", ce);
                }
            }

            cliente.Ce = ce;
        }
    }
}

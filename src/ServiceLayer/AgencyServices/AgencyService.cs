using CRM.NexPolicy.src.DataLayer.Models.Agency;
using CRM.NexPolicy.src.DataLayer.Repository.AgencyRepository;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agency;
using CRM.NexPolicy.src.ViewLayer.DTOs.Agent;
using Microsoft.EntityFrameworkCore;

namespace CRM.NexPolicy.src.ServiceLayer.AgencyServices
{
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _agencyRepository;

        public AgencyService(IAgencyRepository agencyRepository)
        {
            _agencyRepository = agencyRepository;
        }

        public Task<List<AgencyModel>> GetAllAgenciesAsync() => _agencyRepository.GetAllAsync();

        public Task<AgencyModel?> GetAgencyByIdAsync(int id) => _agencyRepository.GetByIdAsync(id);

        public async Task<AgencyModel> CreateAgencyWithIdAsync(int id, string businessName)
        {
            var agency = new AgencyModel
            {
                Id = id,
                BusinessName = businessName,
                CreatedAt = DateTime.UtcNow
            };
            return await _agencyRepository.AddAsync(agency);
        }


        public async Task<bool> UpdateProfileAgencyAsync(int id, CreateAgencyDto dto)
        {
            try
            {
                var existing = await GetAgencyByIdAsync(id);

                if (existing == null)
                    throw new KeyNotFoundException($"Agency with ID {id} not found.");

                existing.BusinessName = dto.BusinessName;
                existing.TaxId = dto.TaxId;
                existing.NPN = dto.NPN;
                existing.Email = dto.Email;
                existing.Phone = dto.Phone;
                existing.Website = dto.Website;
                existing.Address = dto.Address;
                existing.City = dto.City;
                existing.State = dto.State;
                existing.ZipCode = dto.ZipCode;

                return await _agencyRepository.UpdateAsync(existing);
            }
            catch (KeyNotFoundException ex)
            {
                // Manejo específico para agencia no encontrada
                Console.WriteLine($"[Agency Update Error] {ex.Message}");
                throw;
            }
            catch (DbUpdateException ex)
            {
                // Manejo de errores relacionados con la base de datos
                Console.WriteLine($"[Database Error] Failed to update agency: {ex.Message}");
                throw new Exception("There was a problem updating the agency in the database.", ex);
            }
            catch (Exception ex)
            {
                // Otros errores generales
                Console.WriteLine($"[Unexpected Error] {ex.Message}");
                throw new Exception("An unexpected error occurred while updating the agency.", ex);
            }
        }

    }
}

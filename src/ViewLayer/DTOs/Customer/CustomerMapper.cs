using CRM.NexPolicy.src.DataLayer.Models.Customer;

namespace CRM.NexPolicy.src.ViewLayer.DTOs.Customer
{
    public static class CustomerMapper
    {
        public static CustomerModel FromCreateDtoToCustomerModel(CreateCustomerDto dto)
        {
            return new CustomerModel
            {
                //From Lead
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CellPhone = dto.CellPhone,
                Email = dto.Email,

                //From Person
                HomePhone = dto.HomePhone,
                MiddleName = dto.MiddleName,
                DateOfBirth = dto.DateOfBirth,
                GenderId = dto.GenderId,
                SSN = dto.SSN,
                DriversLicenseNumber = dto.DriversLicenseNumber,

                // Customer Info
                Address = dto.Address,
                MedicareBeneficiaryId = dto.MedicareBeneficiaryId,
                MedicareEffectiveDatePartA = dto.MedicareEffectiveDatePartA,
                MedicareEffectiveDatePartB = dto.MedicareEffectiveDatePartB,
                PlanType = dto.PlanType,
                AgentId = dto.AgentId,
                EnrollmentDate = DateTime.UtcNow // se genera aquí por defecto

            };
        }

        

    }

}

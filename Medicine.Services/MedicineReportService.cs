﻿using Medicine.Entities;
using Medicine.Common;
using Medicine.Repository;
using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Services
{
    public class MedicineReportService
    {
        private MedicineReportUnitOfWork _medicineReportUnitOfWork;
        public MedicineReportService()
        {
            _medicineReportUnitOfWork = new MedicineReportUnitOfWork(new MedicineDbContext());
        }

        public string Add(MedicineReport entity)
        {
            try
            {
                var newEntity = new MedicineReport()
                {
                    ComplainantId = entity.ComplainantId,
                    PharmacyId = entity.PharmacyId,
                    MedicineInfoId = entity.MedicineInfoId,
                    AskingPrice = entity.AskingPrice,
                    Comment = entity.Comment,
                    DocumentUrl = entity.DocumentUrl,
                    Status = EnumMedicineReportStatus.Pending
                };

                _medicineReportUnitOfWork.MedicineReportRepository.Add(newEntity);
                _medicineReportUnitOfWork.Save();

                return newEntity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Empty;
            }
        }

        public IEnumerable<MedicineReport> GetAll()
        {
            return _medicineReportUnitOfWork.MedicineReportRepository.GetAll();
        }

        public IEnumerable<MedicineReport> GetAllPending()
        {
            return _medicineReportUnitOfWork.MedicineReportRepository.GetAll().Where(x => x.Status == EnumMedicineReportStatus.Pending);
        }

        public IEnumerable<MedicineReport> GetAllForPharmacy(string id)
        {
            return _medicineReportUnitOfWork.MedicineReportRepository.GetAll()
                .Where(x => (x.Status == EnumMedicineReportStatus.ToPharmacy || x.Status == EnumMedicineReportStatus.Completed) && x.PharmacyId == id);
        }

        public IEnumerable<MedicineReport> GetAllForCompany(string id)
        {
            return _medicineReportUnitOfWork.MedicineReportRepository.GetAll()
                .Where(x => (x.Status == EnumMedicineReportStatus.ToPharmacy || x.Status == EnumMedicineReportStatus.ToComapny || x.Status == EnumMedicineReportStatus.Completed) && x.MedicineInfo.CompanyId == id);
        }

        public void SendFeedback(string medicineReportId, string feedbackMessage)
        {
            var mr = GetById(medicineReportId);
            var cmUser = mr.Complainant;
            var phUser = mr.Pharmacy;

            // Status changed
            ChangeStatus(medicineReportId, EnumMedicineReportStatus.Completed);

            // Add new feedback
            var newFeedback = new ReportFeedback()
            { 
                MedicineReportId = medicineReportId,
                FeedbackMessage = feedbackMessage
            };
            _medicineReportUnitOfWork.MedicineReportRepository.AddFeedback(newFeedback);
            _medicineReportUnitOfWork.Save();

            //Send Email to User
            CustomEmail.SendFeedbackEmail(cmUser.Email, phUser.Name, cmUser.Name, feedbackMessage);
        }

        public IEnumerable<ReportFeedback> GetAllFeedback()
        {
            return _medicineReportUnitOfWork.MedicineReportRepository.GetAllFeedback();
        }

        public void ChangeStatus(string id, EnumMedicineReportStatus status)
        {
            _medicineReportUnitOfWork.MedicineReportRepository.ChangeStatus(id, status);
        }

        public IEnumerable<MedicineReport> GetAllPendingForPharmacy(string id)
        {
            return _medicineReportUnitOfWork.MedicineReportRepository.GetAll()
                .Where(x => x.Status == EnumMedicineReportStatus.ToPharmacy && x.PharmacyId == id);
        }

        public IEnumerable<MedicineReport> GetAllPendingForCompany(string id)
        {
            return _medicineReportUnitOfWork.MedicineReportRepository.GetAll()
                .Where(x => x.Status == EnumMedicineReportStatus.ToComapny && x.MedicineInfo.CompanyId == id);
        }

        public MedicineReport GetById(string id)
        {
            return _medicineReportUnitOfWork.MedicineReportRepository.GetById(id);
        }
    }
}

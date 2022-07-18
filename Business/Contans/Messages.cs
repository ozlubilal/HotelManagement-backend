using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contans
{
    public class Messages
    {
        public static string customerIsAlready="Müşteri zaten kayıtlı";

        public static string CustomerAdded { get; internal set; }
        public static string CustomerUpdated { get; internal set; }
        public static string CustomerDeleted { get; internal set; }
        public static string ImageAdded { get; internal set; }
        public static string ImageDeleted { get; internal set; }
        public static string ImageUpdateted { get; internal set; }
        public static string PaymentSuccess { get; internal set; }
        public static string RentalAdded { get; internal set; }
        public static string RentalDeleted { get; internal set; }
        public static string RentalUpdated { get; internal set; }
        public static string ReservationAdded { get; internal set; }
        public static string ReservationDeleted { get; internal set; }
        public static string ReservationUpdated { get; internal set; }
        public static string RoomClassAdded { get; internal set; }
        public static string RoomClassDeleted { get; internal set; }
        public static string RoomClassUpdated { get; internal set; }
        public static string RoomAdded { get; internal set; }
        public static string RoomDeleted { get; internal set; }
        public static string RoomUpdated { get; internal set; }
        public static string RoomStatuAdded { get; internal set; }
        public static string RoomStatuDeleted { get; internal set; }
        public static string RoomStatuUpdated { get; internal set; }
        public static string StaffDepartmentAdded { get; internal set; }
        public static string StaffDepartmentDeleted { get; internal set; }
        public static string StaffDepartmentUpdated { get; internal set; }
        public static string StaffPositionAdded { get; internal set; }
        public static string StaffPositionDeleted { get; internal set; }
        public static string StaffPositionUpdated { get; internal set; }
        public static string StaffAdded { get; internal set; }
        public static string StaffDeleted { get; internal set; }
        public static string StaffUpdated { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string UserRegistered { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string UserSuccesfulLogin { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static string AccesTokenCreated { get; internal set; }
        public static string UserAdded { get; internal set; }
        public static string UserDeleted { get; internal set; }
        public static string UserUpdated { get; internal set; }
        public static string OperationClaimUpdated { get; internal set; }
        public static string OperationClaimDeleted { get; internal set; }
        public static string OperationClaimAdded { get; internal set; }
        public static string UserOperationClaimAdded { get; internal set; }
        public static string UserOperationClaimAdd { get; internal set; }
        public static string UserOperationClaimUpdated { get; internal set; }
        public static string RoomTypeUpdated { get; internal set; }
        public static string RoomTypeDeleted { get; internal set; }
        public static string RoomTypeAdded { get; internal set; }
        public static string RoomNumberAlreadyExists ="Bu oda numarası kayıtlarda mevcut";
    }
}

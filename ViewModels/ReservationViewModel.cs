namespace HotelBookingWebApp.ViewModels
{
    public class ReservationViewModel
    {
        //Burada OOP prensiplerinde Encapsulation kullandım
        private string? _checkIn;
        private string? _checkOut;
        /*chech-in ve check-out tarihlerini null ise, default olarak şimdiki
         tarihten iki gün sonrasını alsın*/

        public string CheckIn 
        {
            get => _checkIn ?? DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            set => _checkIn = value;
        }
        public string CheckOut
        {
            get => _checkOut ?? DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
            set => _checkOut = value;
        }
    }
}

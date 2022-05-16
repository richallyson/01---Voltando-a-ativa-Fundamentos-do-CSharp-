// using System;

// namespace Payments
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // EVENTS
//             // Eventos são sempre usados juntos com delegate
//             var room = new Room(3);
//             room.RoomSoldOutEvent += OnRoomSoldOut;
//             room.ReserveSeat();
//             room.ReserveSeat();
//             room.ReserveSeat();
//             room.ReserveSeat();
//             room.ReserveSeat();
//             room.ReserveSeat();
//         }

//         static void OnRoomSoldOut(object sender, EventArgs e)
//         {
//             Console.WriteLine("Sala lotada!!");
//         }
//     }

//     public class Room
//     {
//         public int Seats { get; set; }
//         public int SeatsInUse = 0;

//         public Room(int seats)
//         {
//             Seats = seats;
//             SeatsInUse = 0;
//         }

//         public void ReserveSeat()
//         {
//             SeatsInUse++;
//             if (SeatsInUse >= Seats)
//             {
//                 OnRoomSoldOut(EventArgs.Empty);
//             }
//             else
//             {
//                 Console.WriteLine("Assento reservado");
//             }
//         }

//         public event EventHandler RoomSoldOutEvent;

//         protected virtual void OnRoomSoldOut(EventArgs e)
//         {
//             EventHandler handler = RoomSoldOutEvent;
//             handler?.Invoke(this, e);
//         }
//     }

// }
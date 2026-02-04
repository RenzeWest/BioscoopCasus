using BioscoopCasus.Domain;

Console.WriteLine("Hello, World!");

// Movie
Movie movie = new Movie("Interstellar");

// Screening (zaterdag = weekend)
DateTime screeningDate = new DateTime(2026, 2, 7, 20, 0, 0);
MovieScreening screening = new MovieScreening(movie, screeningDate, 12.50);
movie.AddScreening(screening);

// Order (student order = true)
Order order = new Order(orderNr: 1001, isStudentOrder: true);

// Tickets
MovieTicket ticket1 = new MovieTicket(screening, rowNr: 1, seatNr: 1, isPremium: false);
MovieTicket ticket2 = new MovieTicket(screening, rowNr: 1, seatNr: 2, isPremium: true);
MovieTicket ticket3 = new MovieTicket(screening, rowNr: 1, seatNr: 3, isPremium: false);

// Add tickets to order
order.AddSeatReservation(ticket1);
order.AddSeatReservation(ticket2);
order.AddSeatReservation(ticket3);

// Test exports
order.Export(TicketExportFormat.PLAINTEXT);
order.Export(TicketExportFormat.JSON);

Console.WriteLine("Export klaar. Check C:/Downloads/");
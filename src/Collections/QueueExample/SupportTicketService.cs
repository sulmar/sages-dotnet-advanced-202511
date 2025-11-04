namespace QueueExample;

class SupportTicketService
{
    private Queue<Ticket> _queue;

    public void SubmitTicket(Ticket ticket)
    {
        _queue.Enqueue(ticket);

        Console.WriteLine($"New ticket submitted: {ticket}");
    }

    public Ticket ProcessTicket()
    {
        Ticket ticket = _queue.Dequeue();

        Ticket peekTicket = _queue.Peek(); 

        return ticket;
    }

    public IEnumerable<Ticket> GetOpenedTickets()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ticket> GetClosedTickets()
    {
        throw new NotImplementedException();
    }
}
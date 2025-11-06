using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownEventExample;

class AlarmService(int count)
{
    private readonly CountdownEvent countdown = new CountdownEvent(count);

    public void RaiseAlarm(string source)
    {
        Console.WriteLine($"{source}: Wykryto alarm!");
        Thread.Sleep(Random.Shared.Next(500, 1500)); 
        countdown.Signal(); 

        Console.WriteLine($"{source}: Alarm zgłoszony ({countdown.CurrentCount} pozostało).");
    }

    public void WaitForAllAlarms()
    {
        countdown.Wait(); // czeka aż wszystkie alarmy zostaną zgłoszone
                          
        
    }

    

}
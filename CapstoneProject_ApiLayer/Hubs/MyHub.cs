
using CapstoneProject_ApiLayer.DataAccessLayer;
using CapstoneProject_ApiLayer.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject_ApiLayer.Hubs
{
    public class MyHub : Hub
    {
        private readonly Context _context;

        public MyHub(Context context)
        {
            _context = context;
        }

        public static List<string> Names { get; set; } = new List<string>();
        public static int ClientCount { get; set; } = 0;
        public static int roomCount { get; set; } = 7;

        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveNames", Names);
        }
        public async override Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
          
        }

        public async Task SendName(string name)
        {
            if (Names.Count >= roomCount)
            {
                await Clients.Caller.SendAsync("Error", $"Buoda en fazla {roomCount} kişi kadar üye alabilir");
            }
            else
            {
                Names.Add(name);
                await Clients.All.SendAsync("ReceiveName", name);
            }
        }

        public async Task SendNameByGroup(string name, string occupationName )
        {
            var occupation = _context.Occupations.Where(x => x.OccupationName == occupationName).FirstOrDefault();
            if(occupation != null)
            {
                occupation.Users.Add(new User
                {
                    Name = name
                });
            }
            else
            {
                var newOccupation = new Occupation
                {
                    OccupationName = name
                };
                newOccupation.Users.Add(new User { Name = name });
                _context.Occupations.Add(newOccupation);
            }
            await _context.SaveChangesAsync();
            await Clients.Group(occupationName).SendAsync("ReceiveMessageByGroup", name, occupation.OccupationID);
        }

        public async Task GetNamesByGroup()
        {
            var occupations = _context.Occupations.Include(x => x.Users).Select(y => new
            {
                occupationID = y.OccupationID,
                Users = y.Users.ToList()
            });

            await Clients.All.SendAsync("ReceiveNamesByGroup", occupations);
        }

        public async Task AddToGroup(string occupationName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, occupationName);
        }
        //gruptan çıkar
        public async Task RemoveToGroup(string occupationName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, occupationName);

        }

    }
}

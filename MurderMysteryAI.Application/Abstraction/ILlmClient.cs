using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MurderMysteryAI.Domain.Entitities;

namespace MurderMysteryAI.Application.Abstraction
{
    public interface ILlmClient
    {
        IAsyncEnumerable<string> StreamNpcTurnAsync(string npcSystemPrompt, string userMessage, CancellationToken ct);
        Task<NpcTurn> CompleteNpcTurnAsync(string npcSystemPrompt, string userMessage, CancellationToken ct);
    }
}
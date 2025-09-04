using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MurderMysteryAI.Application.Abstraction;
using MurderMysteryAI.Domain.Entitities;

namespace MurderMysteryAI.Application.Implementation
{
    public class LlmClientFake : ILlmClient
    {
        public async IAsyncEnumerable<string> StreamNpcTurnAsync(string npcSystemPrompt, string userMessage, CancellationToken ct)
        {
            var chunks = new []{"{\"Utterance\":\"", "Capisco la tua domanda. ", "Non ero al bar alle 21:10. ", "\",\"Mood\":\"defensive\",\"Claims\":[{\"Subject\":\"NPC_A\",\"Predicate\":\"arrived_at\",\"Object\":\"home\",\"Time\":\"21:10\",\"Certainty\":0.7}],\"PotentialContradictionWith\":[]}"};
            foreach (var c in chunks)
            {
                yield return c;
                await Task.Delay(150, ct);
            }
        }

        public Task<NpcTurn> CompleteNpcTurnAsync(string npcSystemPrompt, string userMessage, CancellationToken ct)
        {
            var turn = new NpcTurn(
                Utterance: "Capisco la tua domanda. Non ero al bar alle 21:10.",
                Mood: NpcMood.defensive,
                Claims: [ new("NPC_A","arrived_at","home","21:10",0.7) ],
                PotentialContradictionWith: []
            );
            return Task.FromResult(turn);
        }
    }
}
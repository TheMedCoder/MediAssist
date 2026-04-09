# Decision Log
A running list of non-obvious choices I made and why.
Future me: read this before asking "who wrote this and what were they thinking."

- Intentionally making a simple API structure to ship fast. Will do Onion later (Api, Application, Domain, & Infrastructure).

## 06 - 04 - 2026 Drug interaction in C# storage
Chose to store interactions as two rows, ( a → b && b → a ) because it makes queries trivial. Risk: Updates can drift, if made a problem come here later. 


~~ A webapp that helps doctors. Drug interactions and triage. Users log in. Built with .NET and React. PostgreSQL for the database. ~~

# MediAssist -- Clinical Decision Support Tool

## Who uses this? 
- Doctors (Full access to everything)
- Nurses (Can triage patients, view drug info, can't manage users)
- Admins (can manage users, can't touch patient data)

## What can they do with it
1. Log in with email and password.
2. Check whether two or more drugs interact with each other.
3. Look up information about a drug (pulled from openFDA).
4. Enter a patient's symptoms and get a triage priority back.
5. See a list of patients they have triaged, most recent first.

## What the system remembers between uses
- Users accounts and their roles. 
- A catalogue of drugs (seeded, updated from openFDA on demand).
- Known drug-drug interactions.
- Triage rules (symptom → score mappings).
- Patient records and their triage history.

## What the system must never do
- Store passwords in plain text. Ever. Not even "just for now."
- Let a user see a patient record that is not theirs, unless they are a doctor or admin.
- Lose a triage result silently.
- Pretend to be a replacement for a doctor's judgment. This is a decision SUPPORT tool.

## OUT OF SCOPE 
- Billing 
- Appointment scheduling 
- Integration with a hospital's existing EMR
- Mobile native app
- HL7/FHIR compliance. One day. Not this month.

## Stack
- Backend: .NET 8 / C# / EF Core
- Database: PostgreSQL
- Frontend: React + TypeScript (Vite)
- Auth: JWT (hand-rolled, no Identity framework)
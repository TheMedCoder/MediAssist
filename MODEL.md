# Data Model (First Pass)

## Nouns

- User (id, email, password hash, name, role created at)

- Patients (id, name, age, sex, medical record number, created by user, created at)

- Drug (id, name, openFDA id, description, last fetched at)

- Interactions (two drugs, severity, description)

- Symptoms (id, name, default severity score, always critical flag)

- Triage Result (id, patient, symptoms observed, total score, priority level, performed by, performed at)



## Verbs

- A user creates many patients.

- A user performs many triage assessments.

- A drug interacts with many other drugs (and those drugs interact with IT — it goes both ways).

- A triage assessment observes many symptoms (with a note per symptom maybe).

- A symptom can appear in many assessments.
Feature: Book Appointment
As a patient, I want to be able to book an appointment in a free slot

@tag1
Scenario: Book Appointment in free slot
	Given The slot with slotId "3FA85F64-5717-4562-B3FC-2C963F66AFA5" is a free slot
	When when the patient try to book this slot using below data
		| id | slotId | patientId | patientName | patientEmail | reservedAt |
		| 3FA85F64-5717-4562-B3FC-2C963F66AFA4 | 3FA85F64-5717-4562-B3FC-2C963F66AFA5 | 3FA85F64-5717-4562-B3FC-2C963F66AFA5 | TestPatient1| TestPatient1@gmail.com | 2025-02-01 |
	Then The slot with slotId "3FA85F64-5717-4562-B3FC-2C963F66AFA5" will be booked correctly

	

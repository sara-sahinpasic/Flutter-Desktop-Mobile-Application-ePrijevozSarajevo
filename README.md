<h3>Flutter-Desktop-Mobile-Application-ePrijevozSarajevo</h3>
<i>Seminar work - Software development 2 - Faculty of Information Technologies</i> </br>
<i>Author: Sara Šahinpašić</i> </br>

## Running the code
- Copy the attached `.env` file to the project root
- Use ```docker-compose up --build``` to start the Docker container.

## Credentials

### Desktop App (Administrator):
	Username: desktop
	Password: test

### Mobile App (User):
	Username: mobile
	Password: test
 
### PayPal test account:
	Email: ePrijevozSarajevo@paypaltest.example.com
	Password: 123456789

## Test Data (Data Seed):
- Routes are generated for the following Dates: 05.01.2025, 15.01.2025, 25.01.2025, 05.02.2025, 15.02.2025, 25.02.2025
- Departure Time-Arrival Time are the same for all dates and routes: 10:15-10:45 

## Microservice:
    RabbitMQ is used for sending an email when Administrator (Desktop) Approves/Rejects Users (Mobile) request for discount status.
    Test email account is created in order to test this behavior. Please see attached `.env` file fields: MOBILE_USER_TEST_EMAIL and MOBILE_USER_TEST_EMAIL_PW.
    It is also possible to create a new mobile user yourself using your own email address so emails are received there.    
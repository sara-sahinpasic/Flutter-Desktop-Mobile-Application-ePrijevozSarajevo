<h3>Flutter-Desktop-Mobile-Application-ePrijevozSarajevo</h3>
<i>Seminar work - Software development 2 - Faculty of Information Technologies</i> </br>
<i>Author: Sara Šahinpašić</i> </br>

## Note
- Određene tabele svjesno ne podržavaju sve CRUD operacije na UI dijelu aplikacije (na backend strani podržano) jer bi u suprotnom nastao direktni 
konflikt sa već prihvaćenim izgledom i obimom funkcionalnosti aplikacije u prijavi teme ovog seminarskog rada.

## Running the code
- Clone the project `git clone https://github.com/sara-sahinpasic/Flutter-Desktop-Mobile-Application-ePrijevozSarajevo.git`
- Navigate to repository root
- Navigate to ePrijevozSarajevo/

### Run backend
- Use ```docker-compose up --build``` to start the Docker container.

### Run desktop app
For running the desktop app you can either build the app and run it or use prebuilt app

#### Running prebuilt desktop app
- Navigate to repository root
- Extract the provided `fit-build-2025-01-06.zip` file
- Navigate to `Desktop_App\`
- Start `eprijevoz_desktop.exe`

#### Building desktop app
- Navigate to UI/eprijevoz_desktop
- Use ```flutter run```
- Choose respective option i.e. ```windows```

### Run mobile app
For running the mobile app you can either build the app and run it or use prebuilt app

#### Running prebuilt mobile app
- Start Android emulator
- Navigate to repository root
- Extract the provided `fit-build-2025-01-06.zip` file
- Navigate to `Mobile_App\`
- Drag and Drop `app-debug.apk` to emulator window and start the app manually
- Instead of Drag and Drop you can also install the app from `Mobile_App\` via `C:\Users\<username>\AppData\Local\Android\Sdk\platform-tools\adb.exe install app-debug.apk`

#### Building mobile app
- Start Android emulator
- Navigate to UI/eprijevoz_mobile
- Use ```flutter run``` 

## Credentials

### Desktop App (Administrator):
	Username: desktop
	Password: test

### Mobile App (User):
	Username: mobile
	Password: test
	Test email: eprijevozsarajevoapp@gmail.com
	Test email password: testTEST123!
 
### PayPal test account:
	Email: ePrijevozSarajevo@paypaltest.example.com
	Password: 123456789

## Test Data (Data Seed):
- Please note that routes are pre-generated for the following dates: **05.01.2025**, **15.01.2025**, **25.01.2025**, **05.02.2025**, **15.02.2025**, **25.02.2025**
- Departure Time-Arrival Time are also pre-generated and are the same for all dates and routes: **10:15-10:45**

## Recommendation system:
- Recommendation system is based on most frequently used route by user. 
- In order to be efficient the Model is trained with new data only on backend application (re)start.
- In the meantime saved model is used for getting the recommendations. 
- See also `my recommender system docx.zip`

## Microservice:
- RabbitMQ is used for sending an email when Administrator (Desktop) Approves/Rejects Users (Mobile) request for discount status.
- Test email account is created in order to test this behavior. See `Test email` and `Test email password` above.
- It is also possible to create a new mobile user yourself using your own email address so emails are received there.
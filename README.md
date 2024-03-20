# Pension-Management-Portal
Led the development of a Pension Management System, automating pension detail provisioning and disbursement processes. This project involved creating middleware microservices for process management, pensioner details, and pension disbursement, integrated within a secure web portal for both administrators and pensioners.

## **MICRO SERVICES FUNCTIONALITY**
Process Pension Microservice:
- Firstly check the pension type.
- Calculate the Pension amount post authentication.
- Return the calculated pension amount. 
- Receive Input from web application.
- 
Pensioner Details Microservice:
- Provide the Information of the registered pensioners.
- It takes Pensioner Aadhar number as an input.

Pension Disbursement Microservice:
- It Disburse the the pensioner pension to its specified bank account.
- It calls two microservice to perform its functionality
   - Process Pension Microservice: (_Pension amount and aadhar details_)
   - Pensioner Details Microservice : (_Bank Details_)
- This microservice is invoked from **Process Pension Microservice**

Authentication Microservice:
- It generates the JWT TOKEN for user authentication purpose.

# EndPoints: 

1. Authorization Microservice: 
[Authorization Microservice](http://52.147.222.252/swagger/index.html)

2. Pension Disbursement Microservice: 
[Pension Disbursement Microservice](http://52.191.87.4/swagger/index.html)

3. Pensioner Details Microservice:
[Pensioner details Microservice](http://52.154.69.176/swagger/index.html)

4. Process Pension Microservice:
[Process Pension Microservice](http://40.76.145.114/swagger/index.html)

---

```
NOTE: To run the project, extract the files and change IP Address in the AppSettings.json file of Penison-Management-Portal and Authorization Microservice to your localhost address.
```

## Repository Structure
-**main branch:**
Contains the project's document.

-**master branch:**
Contains the source code for the Pension Management System.

Please switch to the respective branch to access the related materials for the project.

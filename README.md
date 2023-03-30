# LeaderBankWithMongo
Application about transactions and services, implemented Mongo Atlas like Database.

## Contracts

### Account

<details><summary>Summary</summary>
<p>

![image](https://user-images.githubusercontent.com/98430956/228891194-555eb690-27ea-44d4-8546-43bfda8f8efd.png)

### Get
```json
 {
  "account_Id": "string",
  "id_Customer": "string",
  "id_Card": "string",
  "id_Advisor": "string",
  "accountType": "string",
  "balance": 0,
  "openDate": "2023-03-30T15:56:11.821Z",
  "closeDate": "2023-03-30T15:56:11.821Z",
  "managementCost": 0,
  "accountState": true
}
```
### Post
```json
{
  "id_Customer": "string",
  "id_Card": "string",
  "id_Advisor": "string",
  "accountType": "string",
  "balance": 0,
  "managementCost": 0
}
```
</p>
</details>

### Advisor

<details><summary>Summary</summary>
<p>

![image](https://user-images.githubusercontent.com/98430956/228892417-cf3df4bf-9f83-4d94-a5fc-cf9518db4e8d.png)

### Get
```json
{
  "advisor_Id": "string",
  "names": "string",
  "surNames": "string",
  "address": "string",
  "email": "string",
  "phone": "string",
  "birthdate": "2023-03-30T15:57:08.123Z",
  "gender": "string"
}
```
### Post
```json
{
  "advisor_Id": "string",
  "names": "string",
  "surNames": "string",
  "address": "string",
  "email": "string",
  "phone": "string",
  "birthdate": "2023-03-30T15:57:21.529Z",
  "gender": "string"
}
```

### Get Advisor with Customers
```json
{
    "advisor_Id": "string",
    "names": "string",
    "surNames": "string",
    "address": "string",
    "email": "string",
    "phone": "string",
    "birthdate": "2023-03-30T15:57:42.302Z",
    "gender": "string",
    "customers": [
      {
        "customer_Id": "string",
        "id_Advisor": "string",
        "names": "string",
        "surnames": "string",
        "address": "string",
        "email": "string",
        "phone": "string",
        "birthdate": "2023-03-30T15:57:42.302Z",
        "occupation": "string",
        "gender": "string",
        "state": true
      }
    ]
  }
```

### Get Advisor with Cards
```json
{
    "advisor_Id": "string",
    "names": "string",
    "surNames": "string",
    "address": "string",
    "email": "string",
    "phone": "string",
    "birthdate": "2023-03-30T15:58:33.373Z",
    "gender": "string",
    "cards": [
      {
        "card_Id": "string",
        "id_Advisor": "string",
        "numberCard": "string",
        "cvc": "string",
        "emissionDate": "2023-03-30T15:58:33.373Z",
        "expirationDate": "2023-03-30T15:58:33.373Z",
        "cardState": true
      }
    ]
  }
```

### Get Advisor with Customers, Accounts, Cards and Transactions
```json
{
  "advisor_Id": "string",
  "names": "string",
  "surNames": "string",
  "address": "string",
  "email": "string",
  "phone": "string",
  "birthdate": "2023-03-30T15:58:52.152Z",
  "gender": "string",
  "customers": [
    {
      "customer_Id": "string",
      "id_Advisor": "string",
      "names": "string",
      "surnames": "string",
      "address": "string",
      "email": "string",
      "phone": "string",
      "birthdate": "2023-03-30T15:58:52.152Z",
      "occupation": "string",
      "gender": "string",
      "state": true,
      "accounts": [
        {
          "account_Id": "string",
          "id_Customer": "string",
          "id_Card": "string",
          "id_Advisor": "string",
          "accountType": "string",
          "balance": 0,
          "openDate": "2023-03-30T15:58:52.152Z",
          "closeDate": "2023-03-30T15:58:52.152Z",
          "managementCost": 0,
          "accountState": true,
          "card": {
            "card_Id": "string",
            "id_Advisor": "string",
            "numberCard": "string",
            "cvc": "string",
            "emissionDate": "2023-03-30T15:58:52.152Z",
            "expirationDate": "2023-03-30T15:58:52.152Z",
            "cardState": true
          },
          "transactions": [
            {
              "transaction_Id": "string",
              "id_Account": "string",
              "transactionDate": "string",
              "transactionHour": "string",
              "transactionType": "string",
              "description": "string",
              "amount": 0,
              "oldBalance": 0,
              "finalBalance": 0,
              "transactionProcess": "string",
              "transactionState": true
            }
          ]
        }
      ]
    }
  ]
}
```
</p>
</details>

### Card

<details><summary>Summary</summary>
<p>

![image](https://user-images.githubusercontent.com/98430956/228892572-0ef88123-f7d0-474e-b604-1cf0be3c6691.png)

### Get
```json
  {
    "card_Id": "string",
    "id_Advisor": "string",
    "numberCard": "string",
    "cvc": "string",
    "emissionDate": "2023-03-30T16:12:35.779Z",
    "expirationDate": "2023-03-30T16:12:35.779Z",
    "cardState": true
  }
```
### Post
```json
{
  "card_Id": "string",
  "id_Advisor": "string",
  "numberCard": "string",
  "cvc": "string",
  "emissionDate": "2023-03-30T16:12:47.101Z",
  "expirationDate": "2023-03-30T16:12:47.101Z",
  "cardState": true
}
```
</p>
</details>

### Customer

<details><summary>Summary</summary>
<p>

![image](https://user-images.githubusercontent.com/98430956/228892680-ceaf7577-2022-441d-af07-1874ab0fe532.png)

### Get
```json
  {
    "customer_Id": "string",
    "id_Advisor": "string",
    "names": "string",
    "surnames": "string",
    "address": "string",
    "email": "string",
    "phone": "string",
    "birthdate": "2023-03-30T16:13:43.443Z",
    "occupation": "string",
    "gender": "string",
    "state": true
  }
```
### Post
```json
{
  "customer_Id": "string",
  "id_Advisor": "string",
  "names": "string",
  "surnames": "string",
  "address": "string",
  "email": "string",
  "phone": "string",
  "birthdate": "2023-03-30T16:13:54.579Z",
  "occupation": "string",
  "gender": "string",
  "state": true
}
```
### Get Customer Complete
```json
{
  "customer_Id": "string",
  "id_Advisor": "string",
  "names": "string",
  "surnames": "string",
  "address": "string",
  "email": "string",
  "phone": "string",
  "birthdate": "2023-03-30T16:14:20.340Z",
  "occupation": "string",
  "gender": "string",
  "state": true,
  "accounts": [
    {
      "account_Id": "string",
      "id_Customer": "string",
      "id_Card": "string",
      "id_Advisor": "string",
      "accountType": "string",
      "balance": 0,
      "openDate": "2023-03-30T16:14:20.340Z",
      "closeDate": "2023-03-30T16:14:20.340Z",
      "managementCost": 0,
      "accountState": true,
      "card": {
        "card_Id": "string",
        "id_Advisor": "string",
        "numberCard": "string",
        "cvc": "string",
        "emissionDate": "2023-03-30T16:14:20.340Z",
        "expirationDate": "2023-03-30T16:14:20.340Z",
        "cardState": true
      },
      "transactions": [
        {
          "transaction_Id": "string",
          "id_Account": "string",
          "transactionDate": "string",
          "transactionHour": "string",
          "transactionType": "string",
          "description": "string",
          "amount": 0,
          "oldBalance": 0,
          "finalBalance": 0,
          "transactionProcess": "string",
          "transactionState": true
        }
      ]
    }
  ]
}
```
</p>
</details>

### Transaction

<details><summary>Summary</summary>
<p>

![image](https://user-images.githubusercontent.com/98430956/228892792-73887235-00fd-435e-a38e-e6e5c93e16f8.png)

### Get
```json
  {
    "transaction_Id": "string",
    "id_Account": "string",
    "transactionDate": "string",
    "transactionHour": "string",
    "transactionType": "string",
    "description": "string",
    "amount": 0,
    "oldBalance": 0,
    "finalBalance": 0,
    "transactionProcess": "string",
    "transactionState": true
  }
```
### Post
```json
{
  "id_Account": "string",
  "transactionType": "string",
  "description": "string",
  "amount": 0
}
```
</p>
</details>

Gracias :D 🚀

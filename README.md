# WEBAPICoreProduct
- Date- 30-May-2022
### ASP .Net Coe Web API 
- .Net 5.0, Authentication- None, 
- uncheck - {HTTPS, Docker}
- Check -{Open API Support}


## How to update Record in PostMan

1. Paste URL in "Enter request URL" box like this ==> (http://localhost:43326/api/ComputerProducts/101)
2. select Put Method
3. select body
4. select raw
5. select JSON
6. enter json object like this==> 
    - {
      "productCode": 101,
      "productName": "Speakers",
      "productPrice": 35000.00
      }
      
## How to add record to list using postman
1) select Post method 
2) enter url (http://localhost:43326/api/ComputerProducts)
3) write in body(json format-raw) ==> {
    "productName": "Earphone-Oneplus",
    "productPrice": 1900.00
}
4) we don't required to pass product code as it will be auto generated 
5) press send

## How to delete record from list using postman
1. Select delete method 
2. enter url like this ==> (http://localhost:43326/api/ComputerProducts/112) here 112= product code
3. press send
      
## Note:
  - In visual Studio if we write in Pascal case(ProductCode ) it will converted to Camel case in Swagger/browser/postman (productCode). 
      

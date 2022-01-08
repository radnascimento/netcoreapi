#https://curlconverter.com/
#https://www.nylas.com/blog/use-python-requests-module-rest-apis/
import requests
import ssl
import json

#cert = ssl.get_server_certificate(('127.0.0.1', 5001))
#with open('cert.pem', 'w') as file:
 #   file.write(cert)

url = "https://localhost:5001/api/" 

headers = {
    'accept': '*/*',
    'Content-Type': 'application/json',
}

data = '{"Username":"Rogerio","Password":"1234"}'

response = requests.post('https://localhost:5001/api/Login/Authenticate', headers=headers, data=data , timeout=0.1, verify='cert.pem')
token = response.json()['token']

headers1 = {
    'accept': 'text/plain',
    'Authorization': f'Bareaer {token}',
}

response = requests.get('https://localhost:5001/api/Customer/1', headers=headers1,verify='cert.pem')

print(response)
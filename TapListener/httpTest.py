import requests
postContent = {'TapNumber': 1, 'AmountPoured':  1.03}
request = requests.post('http://192.168.1.2/api/Tap/ProcessPour', json = postContent)
print(request.status_code)
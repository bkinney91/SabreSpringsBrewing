import requests
postContent = {'TapNumber': 1, 'AmountPoured': tap1.getThisPourInPints}
request = requests.post('https://localhost:44301/api/Tap/ProcessPour', data = postContent)
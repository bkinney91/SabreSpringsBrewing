import requests
postContent = {'TapNumber': 1, 'AmountPoured':  1.03}
request = requests.post('http://localhost:51193/api/Tap/ProcessPour', data = postContent)
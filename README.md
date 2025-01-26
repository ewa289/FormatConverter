Convert from a format to json.
Writes the produced json to disk at the same place as the source file using the same name but with "json" extension.

Source format:
```
P|förnamn|efternamn
T|mobilnummer|fastnätsnummer
A|gata|stad|postnummer
F|namn|födelseår
```
eg. of source format:
```
P|Elof|Sundin
T|073-101801|018-101801
A|S:t Johannesgatan 16|Uppsala|75330
F|Hans|1967
A|Frodegatan 13B|Uppsala|75325
F|Anna|1969
T|073-101802|08-101802
P|Boris|Johnson
A|10 Downing Street|London
```
produced json:
```
{
  "people": {
    "person": [
      {
        "firstname": "Elof",
        "lastname": "Sundin",
        "address": {
          "street": "S:t Johannesgatan 16",
          "city": "Uppsala",
          "zip": "75330"
        },
        "phone": {
          "mobile": "073-101801",
          "landline": "018-101801"
        },
        "family": [
          {
            "name": "Hans",
            "born": "1967",
            "address": {
              "street": "Frodegatan 13B",
              "city": "Uppsala",
              "zip": "75325"
            },
            "phone": null
          },
          {
            "name": "Anna",
            "born": "1969",
            "address": null,
            "phone": {
              "mobile": "073-101802",
              "landline": "08-101802"
            }
          }
        ]
      },
      {
        "firstname": "Boris",
        "lastname": "Johnson",
        "address": {
          "street": "10 Downing Street",
          "city": "London",
          "zip": ""
        },
        "phone": null,
        "family": []
      }
    ]
  }
}
```

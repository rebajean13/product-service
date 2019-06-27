let error = true

let res = [
  db.createUser(
    {
      user: "product_user",
      pwd: "password",
      roles: [ { role: "readWrite", db: "product" } ]
    }
  ),
  db.price.createIndex({ ProductId: 1 }, { unique: true }),
  db.auth('product_user','password'),
  db.price.insertOne({ ProductId: "13860428", Value: 13.49, CurrencyCode: "USD" }),
]

printjson(res)

# This file should contain all the record creation needed to seed the database with its default values.
# The data can then be loaded with the rake db:seed (or created alongside the db with db:setup).
#
# Examples:
#
#   cities = City.create([{ name: 'Chicago' }, { name: 'Copenhagen' }])
#   Mayor.create(name: 'Emanuel', city: cities.first)

puts 'creating products...'
in_store_products = Product.create!([
    { name: 'mellby', kind: 'Chair', price_cents: 27900 },
    { name: 'kivik', kind: 'Loveseat', price_cents: 52900 },
    { name: 'hemnes', kind: 'Coffee Table', price_cents: 13900 },
    { name: 'klabb', kind: 'Floor Lamp', price_cents: 8999 },
    { name: 'fredlos', kind: 'Vase', price_cents: 1999 },
    { name: 'formlig', kind: 'Vase', price_cents: 999 }
])

puts 'finished creating products...'

product_reviews = ProductReview.create([
    #Chair reviews
    { product_id: 1, username: 'Loretta', is_positive: true, body: 'I could sit in it all day!' },
    { product_id: 1, username: 'Bobert', is_positive: false, body: 'I lost my cat in it' },
    { product_id: 1, username: 'Elise7849', is_positive: true, body: 'soOooOo comfy' },

    #Loveseat reviews
    { product_id: 2, username: 'Gwen and Alex', is_positive: true, body: 'we love this seat. get it? haha' },
    { product_id: 2, username: 'Josherator', is_positive: true, body: 'my homies love crashin on dis thing' },
    { product_id: 2, username: 'Lovr', is_positive: false, body: 'not big enough for three' },

    #Coffee table reviews
    { product_id: 3, username: 'Annie Holmes', is_positive: true, body: 'very spill resistant' },
    { product_id: 3, username: 'Horton', is_positive: true, body: 'great for those art books you never read' },

    #Lamp reviews
    { product_id: 4, username: 'Alice', is_positive: false, body: 'too bright' },
    { product_id: 4, username: 'StudyBoy', is_positive: true, body: 'great for reading' }
])
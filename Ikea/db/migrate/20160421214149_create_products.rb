class CreateProducts < ActiveRecord::Migration
  def change
    create_table :products do |t|
      t.string :name
      t.string :kind
      t.integer :price_cents

      t.timestamps null: false
    end

    add_index :products, [:kind, :price_cents]
  end
end

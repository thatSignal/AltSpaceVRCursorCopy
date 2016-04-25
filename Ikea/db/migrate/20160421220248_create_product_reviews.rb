class CreateProductReviews < ActiveRecord::Migration
  def change
    create_table :product_reviews do |t|
      t.integer :product_id
      t.string :username
      t.string :body

      t.timestamps null: false
    end

    add_index :product_reviews, :product_id
  end
end

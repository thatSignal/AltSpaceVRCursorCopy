class AddPositivityToReviews < ActiveRecord::Migration
  def change
    add_column :product_reviews, :is_positive, :boolean
  end
end

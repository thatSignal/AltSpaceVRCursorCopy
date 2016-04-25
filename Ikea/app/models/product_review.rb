class ProductReview < ActiveRecord::Base

  validates(
      :username,
      :body,
      :is_positive,
      :presence => true
  )

  belongs_to(
      :product,
      :class_name => "Product",
      :foreign_key => :product_id
  )

  def as_json(options = {})
    super(:except => [:created_at, :updated_at])
  end

end

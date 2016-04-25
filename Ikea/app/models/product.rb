class Product < ActiveRecord::Base

  validates(
      :name,
      :kind,
      :price_cents,
      :presence => true
  )

  has_many(
      :reviews,
      :class_name => "ProductReview",
      :foreign_key => :product_id
  )


  def as_json(options = {})
    super({
          :include => {:reviews => { :except => [:id, :created_at, :updated_at] }},
          :except => [:created_at, :updated_at]
        })
  end

end

class ProductsController < ApplicationController
  respond_to :html, :json

  def index
    @products = Product.all

    puts @products
    respond_to do |format|
      format.html { render :json => @products }
      format.json { render :json => @products }
    end

  end

  def product_params
    params.require(:product).permit(:item_ids)
  end

end

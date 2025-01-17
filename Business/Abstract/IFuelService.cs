﻿using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Entities.Concrete;

namespace Business.Abstract;

public interface IFuelService
{
    public AddFuelResponse Add(AddFuelRequest request);

    public GetFuelListResponse GetList(GetFuelListRequest request);
    public Fuel FindByID(int id);
}

using Application.Common.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ReceiptResourceRepository(DbContext ctx) : BaseRepository<ReceiptResource>(ctx), IReceiptResourceRepository
{
}
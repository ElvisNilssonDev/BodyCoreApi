using TrainingTracker.Domain.Entities;

namespace TrainingTracker.Application.Interfaces;

public interface ITrainingWeekService
{
    Task<List<TrainingWeek>> GetAllAsync(string? search);
    Task<TrainingWeek?> GetByIdAsync(int id);
    Task<TrainingWeek> CreateAsync(TrainingWeek week);
    Task<bool> UpdateAsync(int id, TrainingWeek updated);
    Task<bool> DeleteAsync(int id);
}
